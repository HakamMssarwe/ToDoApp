import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import {BrowserRouter as Router} from "react-router-dom";
import {IsLoadingProvider} from "./Context/IsLoadingContext";

ReactDOM.render(
	<React.StrictMode>
		<Router>
			<IsLoadingProvider>
			<App />
			</IsLoadingProvider>
		</Router>
	</React.StrictMode>,
	document.getElementById("root")
);
