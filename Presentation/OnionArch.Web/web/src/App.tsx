//router manager
import RouterManager from "./routers/RouterManager";
//helpers
import { useAuth } from "./hooks/useAuth";
//components
import LoadingComponent from "./components/LoadingComponent/LoadingComponent";

function App() {
    const { userRole, loading } = useAuth()

    if (loading)
        return <LoadingComponent />

    return (
        <RouterManager userRole={userRole} />
    );
}

export default App;
