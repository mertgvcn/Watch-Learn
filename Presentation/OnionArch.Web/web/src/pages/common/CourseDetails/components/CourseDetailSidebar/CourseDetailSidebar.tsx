import { useState, useEffect } from 'react';
//mui components
import { Box, Divider, Paper, Stack } from '@mui/material'
//models
import { CourseViewModel } from '../../../../../models/viewModels/CourseViewModel';
//helpers
import { formatDuration } from '../../../../../utils/TimeFormatter';
//components
import CoursePreview from './components/CoursePreview';
import Purchasing from './components/Purchasing';
import Stats from './components/Stats';

type CourseDetailSidebarType = {
    course: CourseViewModel,
    isStudentAttendedToCourse: boolean
}

const CourseDetailSidebar = (props: CourseDetailSidebarType) => {
    const {course, isStudentAttendedToCourse} = props

    const formattedTotalLessonDuration = formatDuration(course.totalLessonDurationInSeconds)

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
                        price={course.price}
                        isStudentAttendedToCourse={isStudentAttendedToCourse}
                    />

                    <Divider />

                    <Stats
                        lessonCount={course.lessonCount}
                        attendedStudentCount={course.lessonCount}
                        totalLessonDuration={formattedTotalLessonDuration}
                    />
                </ Stack>
            </Box>
        </Paper>
    )
}

export default CourseDetailSidebar

