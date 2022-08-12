# My Location App Test Task

The basic idea behind this app design is to keep it as simple as possible. 
Eliminating all additional dependencies except the ones required by the task.

## MVVM pattern
The app architecture follows the MVVM pattern. 
App consists of:
<ol>
<li>View. Borderless Window with single ToggleButton</li>
<li>ViewModel. ToggleButton binds its IsChecked property to ViewModel's IsListening property. 
ViewModel interacts with the app model depending on the property value received.</li>
<li>Model consuming services and implementing buiseness logic required by the task.</li>
<li>Services, that interact with different APIs: Speech recognition, Location By User IP and Notepad automated manipulation.</li>
</ol>

## Dependency Injection
Is done by applying Composition Root pattern in it's basic variation inside the MainWindow class.

## Improvements and considerations
This is a bare to the metal design to fulfill all the requirements in the task and not to exceed the time limit provided.
The further improvements for this app, not included:
<ol>
<li>Make single instance app with tray icon, by utilizing Mutex.</li>
<li>Add DI container.</li>
<li>Test coverage. And remove static dependencies from the code.</li>
<li>Implement Reactive pipeline for the data flow: Speech recognition -> Location -> Notepad Modification</li>
</ol>
