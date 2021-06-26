import React, {useState, useContext} from "react";

const UserContext = React.createContext();

export function UserProvider({children}) {
	const [user, setUser] = useState({username:"",password:""});

	return <UserContext.Provider value={{user, setUser}}>{children}</UserContext.Provider>;
}

//Custom hook
export const useUser = () => useContext(UserContext);
