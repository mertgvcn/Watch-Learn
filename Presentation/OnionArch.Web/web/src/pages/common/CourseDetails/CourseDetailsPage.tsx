import { useParams } from 'react-router-dom'
//redux
import { useSelector } from 'react-redux'
import { RootState } from '../../../redux/app/store'
import { selectCourseById } from '../../../redux/features/course/selectors'
//mui components
import { Box, Container, Grid, Stack } from '@mui/material'
//components
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'
import CourseDetailHeader from './components/CourseDetailHeader/CourseDetailHeader'
import CourseDetailSidebar from './components/CourseDetailSidebar/CourseDetailSidebar'
import CourseDetailContent from './components/CourseDetailContent/CourseDetailContent'

const CourseDetailsPage = () => {
    const { id } = useParams()
    const course = useSelector((state: RootState) => selectCourseById(state, Number(id)))

    if (!course) return (<LoadingComponent />)

    return (
        <Box>
            <Grid container sx={{ height: "300px" }}>
                <Grid item xs={12} sx={{
                    height: "100%",
                    backgroundColor: "rgb(35,35,35)",
                    color: "white"
                }}>
                    <Container sx={{ height: "100%" }}>
                        <CourseDetailHeader course={course} />
                    </Container>
                </Grid>
            </Grid>

            <Container>
                <Stack direction="row" spacing={4} marginY="2rem">
                    <CourseDetailContent course={course}/>
                    <CourseDetailSidebar course={course} />
                </Stack>
            </Container>
        </Box>
    )
}

export default CourseDetailsPage

