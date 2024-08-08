import React, { useEffect, useState } from 'react'
//mui components
import { Grid } from '@mui/material'
//components
import CourseCard from './components/CourseCard'
import CourseAPI from '../../../../../utils/APIs/CourseAPI'

const CourseList = () => {
    const [courses, setCourses] = useState([])

    useEffect(() => {
        getCoursesAsync()
    }, [])
    
    const getCoursesAsync = async () => {
        const response = await CourseAPI.GetAllCourses()
        if(response.status == 200) {
            setCourses(response.data)
        }
    }
    
    console.log(courses)
    return (
        <Grid container spacing={4}>
            <Grid item xs={12} sm={6} md={4} lg={3}>
                <CourseCard />
            </Grid>
            <Grid item xs={12} sm={6} md={4} lg={3}>
                <CourseCard />
            </Grid>
            <Grid item xs={12} sm={6} md={4} lg={3}>
                <CourseCard />
            </Grid>
            <Grid item xs={12} sm={6} md={4} lg={3}>
                <CourseCard />
            </Grid>
        </Grid>
    )
}

export default CourseList