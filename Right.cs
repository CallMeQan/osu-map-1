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
    public class Right : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    Dictionary<int, int> StartEndTime = new Dictionary<int, int>(){
                {53742, 62742},
                {65442, 67541},
                {73541, 76092},
                {87041, 91166},
                {96491, 98891},
                {102116, 102641},
                {103842, 104442},
                {108866, 117041},
                {122592, 132641},
                {142016, 144341},
                {146891, 154242},
                {158591, 163466},
                {168192, 173141},
                {175766, 180716},
                {181391, 185591},
                {187841, 194216},
                {246156, 248406},
                {250955, 264455},
                {266105, 275855},
                {276455, 280805},
                {285980, 288305},
                {291605, 292055},
                {293406, 293855},
                {298355, 307055}
            };
            
            foreach (KeyValuePair<int, int> item in StartEndTime)
            {
                var bitmap = GetMapsetBitmap("sb/right.png");
                var bg = GetLayer("").CreateSprite("sb/right.png", OsbOrigin.Centre);
                bg.Scale(item.Key, 480.0f / bitmap.Height);
                bg.Fade(item.Key - 100, item.Key, 0, 1);
                bg.Fade(item.Value, item.Value + 100, 1, 0);
            }
        }
    }
}
