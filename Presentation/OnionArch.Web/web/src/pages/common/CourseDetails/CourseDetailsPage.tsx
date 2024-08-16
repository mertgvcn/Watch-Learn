//redux
import { useSelector } from 'react-redux'
import { selectCourseDetail } from '../../../redux/features/course/selectors'
import { selectIsStudentAttendedToCourse } from '../../../redux/features/student/selectors'
//mui components
import { Box, Container, Grid, Stack } from '@mui/material'
//components
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'
import CourseDetailHeader from './components/CourseDetailHeader/CourseDetailHeader'
import CourseDetailSidebar from './components/CourseDetailSidebar/CourseDetailSidebar'
import CourseDetailContent from './components/CourseDetailContent/CourseDetailContent'

const CourseDetailsPage = () => {
    const courseDetail = useSelector(selectCourseDetail) //bir tek imgUrl şu anda kullanılmıyor 
    const isStudentAttendedToCourse = useSelector(selectIsStudentAttendedToCourse)

    if (!courseDetail || isStudentAttendedToCourse == null) return (<LoadingComponent />)

    return (
        <Box>
            <Grid container sx={{ height: "300px" }}>
                <Grid item xs={12} sx={{
                    height: "100%",
                    backgroundColor: "rgb(35,35,35)",
                    color: "white"
                }}>
                    <Container sx={{ height: "100%" }}>
                        <CourseDetailHeader
                            title={courseDetail.title}
                            shortDescription={courseDetail.shortDescription}
                            teacherName={courseDetail.teacherName}
                        />
                    </Container>
                </Grid>
            </Grid>

            <Container>
                <Stack direction="row" spacing={4} marginY="2rem">
                    <CourseDetailContent
                        description={courseDetail.description}
                        lessons={courseDetail.lessons}
                        comments={courseDetail.courseComments}
                    />
                    <CourseDetailSidebar
                        courseId={courseDetail.id}
                        price={courseDetail.price}
                        studentCount={courseDetail.studentCount}
                        lessonCount={courseDetail.lessonCount}
                        totalLessonDurationInSeconds={courseDetail.totalLessonDurationInSeconds}
                        isStudentAttendedToCourse={isStudentAttendedToCourse}
                    />
                </Stack>
            </Container>
        </Box>
    )
}

export default CourseDetailsPage

