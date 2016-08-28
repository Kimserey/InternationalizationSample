namespace InternationalizationSample

open System
open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html

[<JavaScript>]
module Client =    
    type LocalizerTpl = Templating.Template<"localizer-tpl.html">

    (**
        Provide languages translation
    **)
    let languages =
        [
            { Name = "en-gb"
              Translation = { Div = { Text = "Hello!" } } }

            { Name = "fr"
              Translation = { Div =  { Text = "Bonjour!" } } }
        ]


    let makeTranslationButton code =
        Doc.Button code
            [ attr.style "margin: 1em" ] 
            (fun () -> Localizer.Localize(code))

    let main =

        LocalizerTpl.Text.Doc("Div.Text")
        |> Doc.RunById "text-test"

        LocalizerTpl.Date.Doc(
            date = DateTime.Now.ToString(),
            format = "dddd, MMMM Do YYYY, h:mm:ss a"
        )
        |> Doc.RunById "date-test"
        
        LocalizerTpl.Number.Doc(
            number = "100000000.02",
            format = "0,0.0"
        )
        |> Doc.RunById "number-test"


        divAttr 
            [ on.afterRender(fun e -> 
                Localizer.Init languages
                Localizer.Localize("en-gb")
              ) ]
            [ makeTranslationButton "en-gb"; makeTranslationButton "fr" ]
        |> Doc.RunById "main"
