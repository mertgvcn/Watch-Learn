import { useState, useEffect } from 'react';
//mui components
import { Box, Divider, Paper, Stack } from '@mui/material'
//helpers
import { formatDuration } from '../../../../../utils/TimeFormatter';
//components
import CoursePreview from './components/CoursePreview';
import Purchasing from './components/Purchasing';
import Stats from './components/Stats';

type CourseDetailSidebarType = {
    courseId: number,
    price: number,
    studentCount: number,
    lessonCount: number,
    totalLessonDurationInSeconds: number,
    isStudentAttendedToCourse: boolean
}

const CourseDetailSidebar = (props: CourseDetailSidebarType) => {
    const {courseId, price, totalLessonDurationInSeconds, lessonCount, studentCount, isStudentAttendedToCourse} = props

    const formattedTotalLessonDuration = formatDuration(totalLessonDurationInSeconds)

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
                        courseId={courseId}
                        price={price}
                        isStudentAttendedToCourse={isStudentAttendedToCourse}
                    />

                    <Divider />

                    <Stats
                        studentCount={studentCount}
                        lessonCount={lessonCount}
                        totalLessonDuration={formattedTotalLessonDuration}
                    />
                </ Stack>
            </Box>
        </Paper>
    )
}

export default CourseDetailSidebar

