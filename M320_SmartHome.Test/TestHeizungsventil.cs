using M320_SmartHome;

namespace SmartHomeSimulation.Test
{
    [TestClass]
    public class TestHeizungsventil
    {
        int duration = 20;
        [TestMethod]
        public void midTemp_false()
        {

            var wettersensor = new WettersensorMock(12, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnzimmer", 20);
            wohnung.SetPersonenImZimmer("Wohnzimmer", true);

            var wohnzimmer = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Wohnzimmer");

            Assert.AreEqual(wohnzimmer.HeizungsventilOffen, true);
        }

        [TestMethod]
        public void normalTemp_false()
        {

            var wettersensor = new WettersensorMock(28, 18, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnzimmer", 20);
            wohnung.SetPersonenImZimmer("Wohnzimmer", true);

            var wohnzimmer = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Wohnzimmer");

            Assert.AreEqual(wohnzimmer.HeizungsventilOffen, false);
        }

        [TestMethod]
        public void lowTemp_true()
        {

            var wettersensor = new WettersensorMock(-36, 18, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnzimmer", 21);
            wohnung.SetPersonenImZimmer("Wohnzimmer", true);

            var wohnzimmer = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Wohnzimmer");

            Assert.AreEqual(wohnzimmer.HeizungsventilOffen, true);
        }

        [TestMethod]
        public void highTemp_false()
        {

            var wettersensor = new WettersensorMock(100, 18, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnzimmer", 21);
            wohnung.SetPersonenImZimmer("Wohnzimmer", true);

            var wohnzimmer = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Wohnzimmer");

            Assert.AreEqual(wohnzimmer.HeizungsventilOffen, false);
        }
    }
}