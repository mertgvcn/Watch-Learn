import React from 'react'
import { useParams } from 'react-router-dom'
//redux
import { useSelector } from 'react-redux'
import { RootState } from '../../../redux/app/store'
import { selectCourseById } from '../../../redux/features/course/selectors'

const CourseDetailsPage = () => { 
    const { id } = useParams()
    const course = useSelector((state: RootState) => selectCourseById(state, Number(id)))

    return (
        <div>{JSON.stringify(course)}</div>
    )
}

export default CourseDetailsPage