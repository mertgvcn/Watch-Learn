import React from 'react'
import { Outlet, Route, Routes } from 'react-router-dom'
//models
import { Roles } from '../models/enumerators/Roles'
//mui components
import { Box, Container } from '@mui/material'
//components
import Navbar from '../components/Navbar/Navbar'
//pages
import LoginPage from '../pages/guest/Login/LoginPage'
import RegisterPage from '../pages/guest/Register/RegisterPage'
import ErrorPage from '../pages/common/ErrorPage'

const RouterGuest = () => {
    const Layout = () => {
        return (
            <>
                <Navbar userRole={Roles.Guest}/>
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
                    <Route path='*' element={<ErrorPage />} />
                </Route>
            </Routes>
        </>
    )
}

export default RouterGuest