//router manager
import RouterManager from "./routers/RouterManager";
//helpers
import { useAuth } from "./hooks/useAuth";

function App() {
    const { userRole } = useAuth() 

    return (
        <RouterManager userRole={userRole} />
    );
}

export default App;
