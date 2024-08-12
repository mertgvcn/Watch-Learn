import React, { useEffect } from 'react'
import { useParams } from 'react-router-dom'
//redux
import { RootState, useAppDispatch } from '../../../redux/app/store'
import { useSelector } from 'react-redux'
import { GetCourseById } from '../../../redux/features/course/thunks'
//components
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'
import CourseDetailsPage from './CourseDetailsPage'

const CourseDetailsPageLoader = () => {
    const { id } = useParams()
    const dispatch = useAppDispatch()
    const { loading } = useSelector((state: RootState) => state.course)

    useEffect(() => {
        dispatch(GetCourseById(Number(id)))
    }, [dispatch])

    if (loading) return (<LoadingComponent />)

    return (
        <CourseDetailsPage />
    )
}

export default CourseDetailsPageLoader