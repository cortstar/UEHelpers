# UEHelpers
A repository of commonly-used or useful scripts intended for use in the Unity game development engine.
## Documentation
### Range.cs
Range.cs provides a *serializable* numeric range object. This object is useful for representing a range of possible values, and is especially handy when you need to display such an object in the editor. The object has methods to work with the range, compare numbers to the range, and to map values between ranges.
* Construct with `new Range(float min, float max)`
* `float GetSize()`: Get the numeric length of the range
* `bool  ContainsValue(float  f)`: Check if the range contains the given value
* `float  Range.MapValueBetweenRanges(float  value, Range  from, Range  to)`: Map the given float value between the two given ranges proportionally. For instance, mapping 0.5 from 0-1 to 0-10 will produce 5. This is very handy for scaling.
#### RangeExtensions.cs
RangeExtensions.cs provides an extension method to floats , allowing users to clamp the float to the given range. `float  float.ClampTo( Range  r)`
### Safety.cs
Utilize Safety.cs as shorthand to do frequent null-checking tasks required by the Unity engine. Safety replaces the need to frequently re-write component grabbing code. Can be used to replace the awful [RequiresComponent] attribute.
* `T GameObject.GetComponentSafely<T>()`: Gets the component of type T and logs an error if the component isn't found
* `T GameObject.GetOrAddComponent<T>()`: Gets the component of type T. If it doesn't exist, add the component and return it.
* `bool  GameObject.GetComponentCallbackOrIgnore<T>(ComponentAction<T> action)`: Grab a component and execute the callback on the component without storing the component (good if the component isn't needed later).
### Timer.cs
Just a standard timer class. The class using Timer.cs should manually update the timer by adding `timer.Update()` to it's FixedUpdate loop (don't use `Update()`, for the same reasons you don't want to update physics in`Update()` ).
* Construct with `Timer(float  time)`.
* `float RemainingTime`: remaining time on the timer
* `float StartingTime`: The amount of time the timer starts with (on construction or reset)
* `Pause()`, `Unpause()`, `Reset()` work as expected to manage the timer
* `RegisterTimerCallback(Action  callback)` Register a callback to occur when the timer expires. This doesn't get called if you `Reset()` the timer, at least not until the time is up!
### VectorHelper.cs
Provides extension methods for Unity's `Vector2` and `Vector3` structs.
* `Vector2/Vector3.Componentwise(ComponentOperation  c)`: Perform an action on each component of the vector and return the resultant.
* `Vector2/Vector3.Componentwise(ComponentConditionCheck c)`: Validate that each component of the vector meets some condition `c`, for instance `x => x > 0`