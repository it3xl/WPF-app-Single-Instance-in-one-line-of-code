# WPF app Single Instance in one line of code

## Usage

* Add to your App.xaml.cs or to the main window of your WPF app.

    WpfSingleInstance.Make();

or for all users at once

    WpfSingleInstance.Make(SingleInstanceModes.ForEveryUser);

* Add to your project this modest CSharp file [WpfSingleInstance.cs](https://github.com/it3xl/WPF-app-Single-Instance-in-one-line-of-code/blob/master/WpfSingleInstanceByEventWaitHandle/WpfSingleInstance.cs) or the code from it.

## Differences from MS solution

* No additional inheritance.
* No App.xalm deletion.
* No redundant WCF and Remoting undercover interactions.
* It works with using EventWaitHandle and it is so simple.

I heard that others evolved my approach significantly.<br/>
Look out to those projects too.

But this project will stay small and simple as the initial idea.<br/>

P.S.: Consider a string-name passes to EventWaitHandle as something vulnerable.<br/>
It's your turn for improves )
