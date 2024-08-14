//mui components
import { Box, Container } from '@mui/material'
//components
import MyCourseList from './components/MyCourseList/MyCourseList'

const MyCoursesPage = () => {
    return (
        <Container>
            <Box sx={{ display: "flex", width: "100%", minHeight: "100%", py: 2, boxSizing: "border-box" }}>
                <MyCourseList />
            </Box>
        </Container>
    )
}

export default MyCoursesPage