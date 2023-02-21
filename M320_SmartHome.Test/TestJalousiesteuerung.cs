using M320_SmartHome;

namespace SmartHomeSimulation.Test
{
    [TestClass]
    public class TestJalousiesteuerung
    {
        [TestMethod]
        public void highOutTemp_true()
        {

            var wettersensor = new WettersensorMock(35, 22, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Küche", 20);
            wohnung.SetPersonenImZimmer("Küche", false);

            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");

            Assert.AreEqual(kueche.JalousieHeruntergefahren, true);
        }

        [TestMethod]
        public void lowOutTemp_false()
        {

            var wettersensor = new WettersensorMock(8, 22, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Küche", 20);
            wohnung.SetPersonenImZimmer("Küche", false);

            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");

            Assert.AreEqual(kueche.JalousieHeruntergefahren, false);
        }

        [TestMethod]
        public void noPersInRoom_false()
        {

            var wettersensor = new WettersensorMock(25, 22, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Küche", 20);
            wohnung.SetPersonenImZimmer("Küche", false);

            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");

            Assert.AreEqual(kueche.JalousieHeruntergefahren, true);
        }

        [TestMethod]
        public void highTempPersInRoom_false()
        {

            var wettersensor = new WettersensorMock(29, 22, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Küche", 20);
            wohnung.SetPersonenImZimmer("Küche", true);

            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");

            Assert.AreEqual(kueche.JalousieHeruntergefahren, false);
        }
    }
}