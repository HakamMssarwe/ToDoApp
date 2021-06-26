import React, {useContext} from "react";
import {nameContext} from "./test.js";

export default function TestChild() {
	const name = useContext(nameContext);

	return <div></div>;
}
