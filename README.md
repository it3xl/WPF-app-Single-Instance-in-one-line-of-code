# WPF app Single Instance in one line of code

## Usage

* Add the following code to your App.xaml.cs or to a main window of your WPF app.

To have one instance per user

    WpfSingleInstance.Make();

To have one instance per machine

    WpfSingleInstance.Make(SingleInstanceModes.ForEveryUser);

* Add to your project this modest CSharp file [WpfSingleInstance.cs](https://github.com/it3xl/WPF-app-Single-Instance-in-one-line-of-code/blob/master/WpfSingleInstanceByEventWaitHandle/WpfSingleInstance.cs) or the code from it.

## Differences from MS solution

* No additional inheritance.
* No App.xalm deletion.
* No redundant WCF and Remoting undercover interactions.
* It works with using EventWaitHandle and it is so simple.

I heard that others evolved my approach significantly.<br/>
Look out to those projects too.

P.S.: Consider a string-name passes to EventWaitHandle as something vulnerable.<br/>
Rename it.  
And now it is your turn to make improvements )
