module SkiaStarter
open OpenTK.Mathematics
open OpenTK.Windowing.Common
open OpenTK.Windowing.Desktop
open Window

[<EntryPoint>]
let main argv =
    let nativeSettings =
        new NativeWindowSettings(
            ClientSize = new Vector2i(800, 600),
            Title = "OpenTK Skia F# Starter",            
            Flags = ContextFlags.ForwardCompatible
        )    
    use window = new Window(GameWindowSettings.Default, nativeSettings)
    window.Run()
    0
