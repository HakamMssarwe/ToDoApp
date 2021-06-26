import React, { useState } from 'react'

export const nameContext = React.createContext();


export default function Test() {
 
    const [name,setName] = useState("");


    return (
        <nameContext.Provider value={name}>
            {/*Component*/}
            {/*Component*/}
            {/*Component*/}
            {/*Component*/}
            {/*Component*/}

        </nameContext.Provider>
    )
}
