import { Footer } from "./components/footer/index";
import { Veiculos } from "./components/mainbody/veiculos";
import { Topbar } from "./components/topbar/index";

function App() {
  return (
      <>
          <Topbar />
          <Veiculos />
          <Footer />
      </>
  );
}

export default App;
