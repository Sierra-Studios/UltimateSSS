# About
This plugin is SSS Library (not dependency). It allows creation of elements, dynamically or by inheriting one of the abstract classes.

Static - Not changing settings
Player - Settings change based on player
Dynamic - Not abstract, can be created dynamically (mainly in header)

There is no loop that would go and update it every X seconds, you as the developer have to update it whenever you want. So if I'm working on heatlh system I'll change SSS once I get hit etc.

### Plugin compability
This plugin *should* not rewrite SSS already created, it was tested to work with ASS (it's firstly rewritten and after executing update adds itself on top of it).
- Update is done by: `UltimateSSS.Update(Player player)` or `UltimateSSS.Update(Player player, float delayInSeconds)`

# Credits
@Someone-193 https://github.com/Someone-193/ASS [MIT]
@obvEve https://github.com/obvEve/SecretAPI [MIT]

I mainly took patches, but inspired most from SecretAPI (basically copy of obeEve great system.)
