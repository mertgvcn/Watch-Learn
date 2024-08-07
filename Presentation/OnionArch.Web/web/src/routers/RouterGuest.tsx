import React from 'react'
import { Outlet, Route, Routes } from 'react-router-dom'
import { Box, Container } from '@mui/material'
//components
import Navbar from '../components/Navbar/Navbar'
//pages
import LoginPage from '../pages/guest/Login/LoginPage'
import RegisterPage from '../pages/guest/Register/RegisterPage'

const RouterGuest = () => {
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
                    <Route path='/login' element={<LoginPage />} />
                    <Route path='/register' element={<RegisterPage />} />
                </Route>
            </Routes>
        </>
    )
}

export default RouterGuest