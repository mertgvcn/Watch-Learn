import { useState, useEffect } from 'react';
//mui components
import { Box, Divider, Paper, Stack } from '@mui/material'
//models
import { CourseViewModel } from '../../../../../models/viewModels/CourseViewModel';
//helpers
import { formatDuration } from '../../../../../utils/TimeSpan';
//components
import CoursePreview from './components/CoursePreview';
import Purchasing from './components/Purchasing';
import Stats from './components/Stats';

type CourseDetailSidebarType = {
    course: CourseViewModel,
    isCurrentStudentAttended: boolean
}

const CourseDetailSidebar = (props: CourseDetailSidebarType) => {
    const {course, isCurrentStudentAttended} = props

    const formattedPrice = course.price.toFixed(2)
    const formattedTotalLessonDuration = formatDuration(course.totalLessonDuration)

    const [isFixedSidebar, setIsFixedSidebar] = useState(false);

    useEffect(() => {
        const onScroll = () => setIsFixedSidebar(window.scrollY >= 300);

        window.removeEventListener('scroll', onScroll);
        window.addEventListener('scroll', onScroll, { passive: true });
        return () => window.removeEventListener('scroll', onScroll);
    }, []);

    return (
        <Paper variant='outlined' sx={{
            width: "300px",
            height: "100%",
            position: "sticky",
            top: 84,
            transform: isFixedSidebar ? "" : "translateY(-300px)"
        }}>
            <Box sx={{
                width: "100%",
                height: "fit-content",
            }}>

                <CoursePreview />

                <Stack direction="column" spacing={2} sx={{
                    display: "flex",
                    justifyContent: "center",
                    padding: "1rem",
                    boxSizing: "border-box"
                }}>
                    <Purchasing
                        courseId={course.id}
                        price={Number(formattedPrice)}
                        isCurrentStudentAttended={isCurrentStudentAttended}
                    />

                    <Divider />

                    <Stats
                        lessonCount={course.lessons.length}
                        attendedStudentCount={course.students.length}
                        totalLessonDuration={formattedTotalLessonDuration}
                    />
                </ Stack>
            </Box>
        </Paper>
    )
}

export default CourseDetailSidebar

