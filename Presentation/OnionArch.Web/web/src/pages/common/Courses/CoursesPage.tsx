//mui components
import { Box, Container } from '@mui/material'
//components
import CourseList from './components/CourseList/CourseList'

const CoursesPage = () => {
    return (
        <Container>
            <Box sx={{ display: "flex", width: "100%", minHeight: "100%", py: 2, boxSizing: "border-box" }}>
                <CourseList />
            </Box>
        </Container>
    )
}

export default CoursesPage