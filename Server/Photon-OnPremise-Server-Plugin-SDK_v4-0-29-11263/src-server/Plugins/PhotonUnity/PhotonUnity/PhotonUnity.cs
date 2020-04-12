using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon.Hive.Plugin;

namespace PhotonUnity
{
    public class PhotonUnity : PluginBase
    {
        public override string Name => "PhotonUnity";
        public override void OnCreateGame(ICreateGameCallInfo info)
        {
            info.Continue();
        }
    }
}
