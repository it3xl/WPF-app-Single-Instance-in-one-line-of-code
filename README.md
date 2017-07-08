# WPF app Single Instance in one line of code usage

Usage: WpfSingleInstance.Make(); or WpfSingleInstance.Make(SingleInstanceModes.ForEveryUser);

1. Add only a line of code of above to your App.xaml.cs or to the main window of your WPF app.
1. Add to your project this modest CSharp file [WpfSingleInstance.cs](https://github.com/it3xl/WPF-app-Single-Instance-in-one-line-of-code/blob/master/WpfSingleInstanceByEventWaitHandle/WpfSingleInstance.cs) or code from it.

* No additional inheritance.
* No App.xalm deleting.
* No such redundant WCF and Remoting undercover interactions.
* It works by the EventWaitHandle and it is so simple.

I know others who evolved my approach from here. And this is great.<br/>
But I was needed a reliable, robust, simple and small solution just for that time.

P.S.: I wasn't worried about security of a string-name for EventWaitHandle. It's your turn now )
