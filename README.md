# PleadIgnorance
A V Rising server plugin made to make sure players acknowledge the rules before entering!

## Features
🔁 Force players to acknowledge a message before exiting the spawn cave.<br>
⚙️ Customizable header, message and footer<br>
🖌️ Style text with rich text tags [Unity Documentation](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html)<br>

## How It Works
Players must read & acknowledge a custom message shown in chat before being able to leave the spawn cave area. Once the player types .accept in chat they will be able to teleport out of the spawn cave area.

<img src="https://i.ibb.co/pBd14y9Y/Screenshot-20250521-193336.png"/>

## Installing PleadIgnorance
1️⃣ Navigate to the server install folder. Typically: `ServerDirectory/BepInEx/plugins`<br>

2️⃣ Make sure you have the latest version of [BepInEx](https://thunderstore.io/c/v-rising/p/BepInEx/BepInExPack_V_Rising/) as well as [VampireCommandFramework](https://thunderstore.io/c/v-rising/p/deca/VampireCommandFramework/)<br>

3️⃣ ️Place the `PleadIgnorance.dll` file inside the `ServerDirectory\BepInEx\plugins` folder.<br>

## Configuration
The header, footer & message text can be configured in the files found inside `ServerDirectory/BepInEx/config/PleadIgnorance`

```cfg
<color=#ffffffff>Rule 1:</color> Dont be an asshole.
<color=#ffffffff>Rule 2:</color> <b>You can</b>
<color=#ffffffff>Rule 3:</color> <i>Also use</i>
<color=#ffffffff>Rule 4:</color> <size=10>Rich text</size>
<color=#ffffffff>Rule 5:</color> <size=15>Formatting in</size>
<color=#ffffffff>Rule 6:</color> <size=20>The <color=#add8e6ff>Message</color></size>
```

```cfg
[Options]

## Prevent cave exit until player accepts the rules.
# Setting type: Boolean
# Default value: true
PreventCaveExit = true

[Text]

## Message header text
# Setting type: String
# Default value: <color=#add8e6ff>Server Rules</color>
Header = <color=#add8e6ff>Server Rules</color>

## Message footer text
# Setting type: String
# Default value: Type <color=#ffff00ff><b>.accept</b></color> to continue
Footer = Type <color=#ffff00ff><b>.accept</b></color> to continue
```

### Credits
🧛 [V Rising Modding Community](https://wiki.vrisingmods.com/)  |  [Discord](https://discord.com/invite/QG2FmueAG9)

### Support & Bug reports
Join the V Rising Modding Community discord with the link above and create a post in the `🙋|Technical Support` channel and tag `#helskog`

### License
[This project is licensed under the AGPL-3.0 license.](https://choosealicense.com/licenses/agpl-3.0/#)
