import { Outlet, Route, Routes } from 'react-router-dom'
//models
import { Roles } from '../models/enumerators/Roles'
//mui components
import { Container } from '@mui/material'
//components
import Navbar from '../components/Navbar/Navbar'
//pages
import HomePage from '../pages/student/Home/HomePage'
import ProfilePage from '../pages/student/Profile/ProfilePage'
import ErrorPage from '../pages/common/ErrorPage'
import CoursePage from '../pages/student/Course/CoursePage'

const RouterStudent = () => {
    const Layout = () => {
        return (
            <>
                <Navbar userRole={Roles.Student}/>
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
                    <Route path='/' element={<HomePage />} />
                    <Route path='/profile' element={<ProfilePage />} />
                    <Route path='/courses' element={<CoursePage />} />
                    <Route path='*' element={<ErrorPage />} />
                </Route>
            </Routes>
        </>
    )
}

export default RouterStudent