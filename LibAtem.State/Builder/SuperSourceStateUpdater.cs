using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Commands.SuperSource;

namespace LibAtem.State.Builder
{
    internal static class SuperSourceStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is SuperSourceConfigV8Command conf8Cmd)
            {
                UpdaterUtil.TryForIndex(result, state.SuperSources, (int) conf8Cmd.SSrcId, ssrc =>
                {
                    ssrc.Boxes = UpdaterUtil.CreateList(conf8Cmd.Boxes, (i) => new SuperSourceState.BoxState());
                    result.SetSuccess($"SuperSources.{conf8Cmd.SSrcId:D}.Boxes");
                });
            }
            else if (command is SuperSourceConfigCommand confCmd)
            {
                UpdaterUtil.TryForIndex(result, state.SuperSources, 0, ssrc =>
                {
                    ssrc.Boxes = UpdaterUtil.CreateList(confCmd.Boxes, (i) => new SuperSourceState.BoxState());
                    result.SetSuccess($"SuperSources.0.Boxes");
                });
            }
            else if (command is SuperSourceBoxGetV8Command box8Cmd)
            {
                UpdaterUtil.TryForIndex(result, state.SuperSources, (int) box8Cmd.SSrcId, ssrc =>
                {
                    UpdaterUtil.TryForIndex(result, ssrc.Boxes, (int) box8Cmd.BoxIndex, box =>
                    {
                        UpdaterUtil.CopyAllProperties(box8Cmd, box, new []{"SSrcId", "BoxIndex"});
                        result.SetSuccess($"SuperSources.{box8Cmd.SSrcId:D}.Boxes.{box8Cmd.BoxIndex:D}");
                    });
                });
            }
            else if (command is SuperSourceBoxGetCommand boxCmd)
            {
                UpdaterUtil.TryForIndex(result, state.SuperSources, 0, ssrc =>
                {
                    UpdaterUtil.TryForIndex(result, ssrc.Boxes, (int) boxCmd.Index, box =>
                    {
                        UpdaterUtil.CopyAllProperties(boxCmd, box, new []{"Index"});
                        result.SetSuccess($"SuperSources.0.Boxes.{boxCmd.Index:D}");
                    });
                });
            }
            else if (command is SuperSourcePropertiesGetV8Command prop8Cmd)
            {
                UpdaterUtil.TryForIndex(result, state.SuperSources, (int) prop8Cmd.SSrcId, ssrc =>
                {
                    UpdaterUtil.CopyAllProperties(prop8Cmd, ssrc.Properties, new []{"SSrcId"});
                    result.SetSuccess($"SuperSources.{prop8Cmd.SSrcId:D}.Properties");
                });
            }
            else if (command is SuperSourceBorderGetCommand borderCmd)
            {
                UpdaterUtil.TryForIndex(result, state.SuperSources, (int) borderCmd.SSrcId, ssrc =>
                {
                    UpdaterUtil.CopyAllProperties(borderCmd, ssrc.Border, new []{"SSrcId"});
                    result.SetSuccess($"SuperSources.{borderCmd.SSrcId:D}.Border");
                });
            }
            else if (command is SuperSourcePropertiesGetCommand propCmd)
            {
                UpdaterUtil.TryForIndex(result, state.SuperSources, 0, ssrc =>
                {
                    UpdaterUtil.CopyAllProperties(propCmd, ssrc.Properties, new[]
                    {
                        "BorderEnabled",
                        "BorderBevel",
                        "BorderOuterWidth",
                        "BorderInnerWidth",
                        "BorderOuterSoftness",
                        "BorderInnerSoftness",
                        "BorderBevelSoftness",
                        "BorderBevelPosition",
                        "BorderHue",
                        "BorderSaturation",
                        "BorderLuma",
                        "BorderLightSourceAltitude",
                        "BorderLightSourceDirection",
                    });
                    
                    ssrc.Border.Enabled = propCmd.BorderEnabled;
                    ssrc.Border.Bevel= propCmd.BorderBevel;
                    ssrc.Border.OuterWidth = propCmd.BorderOuterWidth;
                    ssrc.Border.InnerWidth = propCmd.BorderInnerWidth;
                    ssrc.Border.OuterSoftness = propCmd.BorderOuterSoftness;
                    ssrc.Border.InnerSoftness = propCmd.BorderInnerSoftness;
                    ssrc.Border.BevelSoftness = propCmd.BorderBevelSoftness;
                    ssrc.Border.BevelPosition = propCmd.BorderBevelPosition;
                    ssrc.Border.Hue = propCmd.BorderHue;
                    ssrc.Border.Saturation = propCmd.BorderSaturation;
                    ssrc.Border.Luma = propCmd.BorderLuma;
                    ssrc.Border.LightSourceDirection = propCmd.BorderLightSourceDirection;
                    ssrc.Border.LightSourceAltitude = propCmd.BorderLightSourceDirection;

                    result.SetSuccess($"SuperSources.0.Properties");
                    result.SetSuccess($"SuperSources.0.Border");
                });
            }
        }

    }
}