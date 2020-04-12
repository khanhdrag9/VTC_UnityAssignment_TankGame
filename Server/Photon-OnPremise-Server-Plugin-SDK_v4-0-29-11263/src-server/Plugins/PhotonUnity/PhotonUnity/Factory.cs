using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon.Hive.Plugin;

namespace PhotonUnity
{
    class Factory : IPluginFactory
    {
        public IGamePlugin Create(IPluginHost gameHost, string pluginName, Dictionary<string, string> config, out string errorMsg)
        {
            PhotonUnity output = new PhotonUnity();
            bool r = output.SetupInstance(gameHost, config, out errorMsg);
            return r ? output : null;
        }
    }
}
