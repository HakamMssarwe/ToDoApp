import "./App.css";
import {Route} from "react-router-dom";
import {Login} from "./Routes/index.js";
import {Register} from "./Routes/index.js";
import Loading from "./Components/Loading/loading.jsx";
import {useIsLoading} from "./Context/IsLoadingContext";

function App() {
	const {isLoading} = useIsLoading();
	return (
		<div className="App">
				{isLoading && <Loading />}
				<Route exact path="/" component={Login} />
				<Route exact path="/register" component={Register} />
		</div>
	);
}

export default App;
