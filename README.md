# Rakis.Settings - A library for managing application settings

On Windows we have a lot of places where we could store application settings. This library allows you to load and store settings from a few of the most common locations on Windows:

- `ProgramData`

  This location is intended for system-wide settings which are common for all users using the app. A normal user may not have the rights to create directories here, so if you use this location you'll have to check if that is the case for you. The "`ProgramData`" directory is "hidden", so you may not see it.

  Normally there is first a directory related to the application developer or company, with a second level for the actual application. For example, Lockheed Martin Prepar3D version 4 uses "`C:\ProgramData\Lockheed Martin\Prepar3D v4`", while version 5 uses "`C:\ProgramData\Lockheed Martin\Prepar3D v5`".

- `AppData`

  This location is for user-specific settings, so it lies under the user's home directory, again as a hidden directory. If you username is "`user`", you can find this folder as "`C:\Users\user\AppData`".

  The `AppData` folder has 3 sub-folders:

  * `Local`

    The settings here are specific for this particular machine.

  * `Roaming`

    The settings here are valid on whichever machine this user logs on and will be synchronized between them, _if_ the machines are part of a managed Windows Domain.

  * `LocalLow`

    This is a special version of `Local` that has the lowest possible security setting. This means that any kind of excutable content here will be isolated for security reasons.

  Just like with `ProgramData` an additional two levels are used here, so the roaming settings for Prepar3D v5 are in "`C:\Users\user\AppData\Roaming\Lockheed Martin\Prepar3D v5`".

- Some applications store settings in the user's home directory, so at the same level as the "`AppData`" directory, although it is pretty common to create a subdirectory for the app.
- Another alternative is to start in the "`Documents`" directory. Note that this directory is probably roaming and often synchronized with OneDrive Cloud storage-like solution.
- Lastly, you can use the current working directory, making it dependent on how the app is started. Please note that, on Windows, it used to be quite common to do this with the application running in its installation directory. The result was that settings ended up in "`Program Files`" which is nowadays usually forbidden. It is also a bad habit, because you'd lose the settings if you uninstall the app or install a newer version on top of it.