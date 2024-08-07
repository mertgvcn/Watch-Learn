//mui components
import { Box } from '@mui/material'
//components
import Login from './components/Login'

const LoginPage = () => {
    return (
        <Box sx={{
            width: "100%",
            minHeight: "calc(100vh - 64px)",
            py: 2,
            boxSizing: "border-box",
            display: "flex",
            alignItems: "center",
            justifyContent: "center"
        }}>
            <Login />
        </Box>
    )
}

export default LoginPage