import { Outlet, Route, Routes } from 'react-router-dom'
//mui components
import { Container } from '@mui/material'
//components
import Navbar from '../components/Navbar/Navbar'

const RouterStudent = () => {
    const Layout = () => {
        return (
            <>
                <Navbar />
                <Container>
                    <Outlet />
                </Container>
            </>
        )
    }

    return (
        <>
            <Routes>
                <Route path='/' element={<Layout />}>
                    <Route path='/' element={<LoginPage />} />
                </Route>
            </Routes>
        </>
    )
}

export default RouterStudent