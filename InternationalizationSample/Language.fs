namespace InternationalizationSample

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html

[<JavaScript>]
type Language = {
    Name: string
    Translation: Translation
}
and Translation = {
    Div: Div
}
and Div = {
    Text: string
}