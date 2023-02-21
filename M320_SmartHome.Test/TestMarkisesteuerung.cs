using M320_SmartHome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartHomeSimulation.Test
{
    
    public class TestMarkisesteuerung
    {

        [TestMethod]
        public void wind_false()
        {

            var wettersensor = new WettersensorMock(25, 45, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");

            Assert.AreEqual(wintergarten.MarkiseOffen, false);
        }

        [TestMethod]
        public void higherOutTemp_false()
        {

            var wettersensor = new WettersensorMock(29, 45, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");

            Assert.AreEqual(wintergarten.MarkiseOffen, false);
        }

        [TestMethod]
        public void warmNoRain_true()
        {

            var wettersensor = new WettersensorMock(15, 35, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");

            Assert.AreEqual(wintergarten.MarkiseOffen, true);
        }

        [TestMethod]
        public void rainWind_true()
        {
            var wettersensor = new WettersensorMock(25, 45, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");

            Assert.AreEqual(wintergarten.MarkiseOffen, true);
        }
    }
}