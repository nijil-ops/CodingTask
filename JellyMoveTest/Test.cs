using JellyMoveLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyMoveTest
{
    public class Test
    {
        [Test]
        public void ExtractInputAndGenerateResult()
        {
            var jelly = new Jelly(5, 3, "E");
            var expected = new List<Jelly>() { new Jelly(1, 1, "E") };

            string input = "53\r\n11E RFRFRFRF\r\n";
            var objInput = new Input();
            List<Jelly> lstJelly = objInput.ExtractInputAndGenerateResult(input);
            var expectedJson = Newtonsoft.Json.JsonConvert.SerializeObject(lstJelly);
            var actualJson = Newtonsoft.Json.JsonConvert.SerializeObject(lstJelly);
            //assert
            Assert.AreEqual(actualJson, expectedJson);
        }
    }
}
