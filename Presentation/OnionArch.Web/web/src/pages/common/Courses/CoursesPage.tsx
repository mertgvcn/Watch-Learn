//redux
import { useSelector } from 'react-redux'
import { selectCourses } from '../../../redux/features/course/selectors'
//mui components
import { Box, Container } from '@mui/material'
//components
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'
import CourseList from './components/CourseList/CourseList'

const CoursesPage = () => {
    const courses = useSelector(selectCourses)

    if (!courses) return (<LoadingComponent />)

    return (
        <Container>
            <Box sx={{ display: "flex", width: "100%", minHeight: "100%", py: 2, boxSizing: "border-box" }}>
                <CourseList courses={courses}/>
            </Box>
        </Container>
    )
}

export default CoursesPage