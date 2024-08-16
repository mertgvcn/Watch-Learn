//redux
import { useSelector } from 'react-redux'
import { selectCurrentStudentCourses } from '../../../../../redux/features/student/selectors'
//mui components
import { Grid, Typography } from '@mui/material'
//components
import MyCourseCard from '../../../../student/MyCourses/components/MyCourseList/components/MyCourseCard'

const MyCourseList = () => {
    const courses = useSelector(selectCurrentStudentCourses)

    return (
        <>
            {courses &&
                <Grid container spacing={4}>
                    <Grid item xs={12} sx={{ marginBottom: "-16px" }}>
                        <Typography variant='h5'>My Courses</Typography>
                    </Grid>

                    {courses.map((course, index) => (
                        <Grid item xs={12} sm={6} md={4} lg={3} key={index}>
                            <MyCourseCard data={course} />
                        </Grid>
                    ))}
                </Grid>
            }
        </>
    )
}

export default MyCourseList