// A place to store all of our stores

import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";

interface Store {
    activityStore: ActivityStore
}

export const store: Store = {
    activityStore: new ActivityStore()
}

// React hook
export const StoreContext = createContext(store);

// React hook to allow us to use our stores inside our components
export function useStore() {
    return useContext(StoreContext); //also a react hook
}