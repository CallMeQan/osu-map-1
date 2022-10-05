using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Left : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    Dictionary<int, int> StartEndTime = new Dictionary<int, int>(){
                {43391, 53591},
                {62891, 65291},
                {67616, 76092},
                {76692, 86592},
                {91317, 96491},
                {98967, 102041},
                {102641, 103842},
                {104442, 108717},
                {112166, 117041},
                {133016, 142091},
                {144492, 146891},
                {149216, 158442},
                {163917, 168341},
                {173141, 175692},
                {179216, 179516},
                {180792, 181391},
                {185742, 194216},
                {243755, 246455},
                {248481, 251406},
                {253281, 264455},
                {266105, 275855},
                {280805, 285906},
                {288305, 298055},
                {301656, 307055}
            };
            
            foreach (KeyValuePair<int, int> item in StartEndTime)
            {
                var bitmap = GetMapsetBitmap("sb/left.png");
                var bg = GetLayer("").CreateSprite("sb/left.png", OsbOrigin.Centre);
                bg.Scale(item.Key, 480.0f / bitmap.Height);
                bg.Fade(item.Key - 100, item.Key, 0, 1);
                bg.Fade(item.Value, item.Value + 100, 1, 0);
            }
        }
    }
}
