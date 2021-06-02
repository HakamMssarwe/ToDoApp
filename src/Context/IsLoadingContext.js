import React, {useState, useContext} from "react";

const IsLoadingContext = React.createContext();

export function IsLoadingProvider({children}) {
	const [isLoading, setIsLoading] = useState(false);

	return <IsLoadingContext.Provider value={{isLoading, setIsLoading}}>{children}</IsLoadingContext.Provider>;
}

//Custom hook
export const useIsLoading = () => useContext(IsLoadingContext);
