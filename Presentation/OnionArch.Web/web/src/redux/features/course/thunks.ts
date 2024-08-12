import { createAsyncThunk } from "@reduxjs/toolkit"
//api
import CourseAPI from "../../../utils/APIs/CourseAPI"
//models
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel"

export const GetAllCourses = createAsyncThunk<CourseViewModel[]>(
    'Course/GetAllCourses',
    async () => {
        const response = await CourseAPI.GetAllCourses()
        return response.data
    }
)

export const GetCourseById = createAsyncThunk<CourseViewModel, number>(
    'Course/GetCourseById',
    async (id: number) => {
        const response = await CourseAPI.GetCourseById(id)
        return response.data
    }
)