//mui components
import { Grid, Stack, Typography } from '@mui/material'
//components
import CourseCard from './components/CourseCard'
import { useSelector } from 'react-redux'
import { selectCourses } from '../../../../../redux/features/course/selectors'

const CourseList = () => {
    const courses = useSelector(selectCourses)

    return (
        <>
            <Grid container spacing={4}>
                <Grid item xs={12} sx={{ marginBottom: "-16px" }}>
                    <Typography variant='h5'>All Courses</Typography>
                </Grid>

                {courses.map((course, index) => (
                    <Grid item xs={12} sm={6} md={4} lg={3} key={index}>
                        <CourseCard data={course} />
                    </Grid>
                ))}
            </Grid>
        </>
    )
}

export default CourseList