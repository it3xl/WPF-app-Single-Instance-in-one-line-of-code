# WPF app Single Instance in one line of code

## Usage

* Add the following code to your App.xaml.cs or to a main window of your WPF app.

To have a single instance per user's Windows session:

    WpfSingleInstance.Make("MyWpfApplication");

To have one instance per machine:

    WpfSingleInstance.Make("MyWpfApplication", uniqPerUser: false);

* Add to your project this modest CSharp file [WpfSingleInstance.cs](https://github.com/it3xl/WPF-app-Single-Instance-in-one-line-of-code/blob/master/WpfSingleInstanceByEventWaitHandle/WpfSingleInstance.cs) or entire code from it.

## Example

This repository contains a small WPF-application. You can build and run it to give it a try.

## Differences from MS solution

* No additional inheritance.
* No App.xalm deletion.
* No redundant WCF and Remoting undercover interactions.
* It works with using of EventWaitHandle and it is so simple.

I heard that others evolved my approach significantly. Look out to those projects too.

P.S.: Consider passing of a string-name to EventWaitHandle.OpenExisting(...) as something vulnerable.<br/>

Now it's your turn to make improvements for this approach :)
