import React from 'react'
//mui components
import { Box } from '@mui/material'
//components
import CourseList from './components/CourseList/CourseList'

const CoursePage = () => {
    return (
        <Box sx={{ display: "flex", width: "100%", minHeight: "100%", py: 2, boxSizing: "border-box" }}>
            <CourseList />
        </Box>
    )
}

export default CoursePage