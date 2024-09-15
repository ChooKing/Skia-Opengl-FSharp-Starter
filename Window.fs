module Window

open System;
open OpenTK.Windowing.Common;
open OpenTK.Windowing.Desktop;
open OpenTK.Graphics.OpenGL4;
open SkiaSharp

type Window(gameWindowSettings, nativeWindowSettings) =
    inherit GameWindow(gameWindowSettings, nativeWindowSettings)
    let mutable time = 0.0
    [<DefaultValue>]
    val mutable grgInterface: GRGlInterface
    [<DefaultValue>]
    val mutable grContext: GRContext
    [<DefaultValue>]
    val mutable surface: SKSurface
    [<DefaultValue>]
    val mutable canvas: SKCanvas
    [<DefaultValue>]
    val mutable renderTarget: GRBackendRenderTarget
    [<DefaultValue>]
    val mutable TestBrush: SKPaint
    
    override this.OnLoad() =
        base.OnLoad()
        this.grgInterface <- GRGlInterface.Create()
        this.grContext <- GRContext.CreateGl(this.grgInterface)
        this.renderTarget <- new GRBackendRenderTarget(this.ClientSize.X, this.ClientSize.Y, 0, 8, new GRGlFramebufferInfo(0u, (uint)SizedInternalFormat.Rgba8))
        this.surface <- SKSurface.Create(this.grContext, this.renderTarget, GRSurfaceOrigin.BottomLeft, SKColorType.Rgba8888)
        this.canvas <- this.surface.Canvas
        this.TestBrush <- new SKPaint(Color = SKColors.White, IsAntialias = true, Style = SKPaintStyle.Fill, TextAlign = SKTextAlign.Center, TextSize = 24.0f)
    override this.OnUnload() =
        this.TestBrush.Dispose()
        this.surface.Dispose()
        this.renderTarget.Dispose()
        this.grContext.Dispose()
        this.grgInterface.Dispose()
        base.OnUnload()
    override this.OnRenderFrame(args:FrameEventArgs) =        
        this.canvas.Clear(SKColors.CornflowerBlue)
        this.TestBrush.Color <- SKColors.MediumSeaGreen      
        this.canvas.DrawRoundRect(new SKRoundRect(SKRect(0f, 0f, 256f, 256f), 30f, 30f), this.TestBrush)
        this.TestBrush.Color <- SKColors.Black
        this.canvas.DrawText("Hello, World!", 128f, 30f, this.TestBrush)
        this.canvas.Flush();
        this.SwapBuffers()
