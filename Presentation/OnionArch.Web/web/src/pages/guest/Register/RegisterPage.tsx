//mui components
import { Box } from '@mui/material'
//components
import Register from './components/Register'

const RegisterPage = () => {
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
            <Register />
        </Box>
    )
}

export default RegisterPage