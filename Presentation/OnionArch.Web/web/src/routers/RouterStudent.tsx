import { Outlet, Route, Routes } from 'react-router-dom'
//models
import { Roles } from '../models/enumerators/Roles'
//mui components
import { Box, Container } from '@mui/material'
//components
import Navbar from '../components/Navbar/Navbar'
//pages
import HomePage from '../pages/student/Home/HomePage'
import ProfilePage from '../pages/student/Profile/ProfilePage'
import ErrorPage from '../pages/common/Error/ErrorPage'
import CoursesPageLoader from '../pages/common/Courses/CoursesPageLoader'
import CourseDetailsPageLoader from '../pages/common/CourseDetails/CourseDetailsPageLoader'
import Footer from '../components/Footer/Footer'

const RouterStudent = () => {
    const Layout = () => {
        return (
            <>
                <Navbar userRole={Roles.Student} />
                <Box minHeight="calc(100vh - 64px)">
                    <Outlet />
                </Box>
                <Footer />
            </>
        )
    }

    return (
        <>
            <Routes>
                <Route path='/' element={<Layout />}>
                    <Route path='/' element={<HomePage />} />
                    <Route path='/profile' element={<ProfilePage />} />
                    <Route path='/courses' element={<CoursesPageLoader />} />
                    <Route path='/courses/:id' element={<CourseDetailsPageLoader />} />
                    <Route path='*' element={<ErrorPage />} />
                </Route>
            </Routes>
        </>
    )
}

export default RouterStudent