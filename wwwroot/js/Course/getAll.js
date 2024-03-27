 $(document).ready(function () {
            
            $.ajax({
                url: '/Course/GetCourses',
                dataType: "json",
                method: 'GET',
                success: function (result) {
                    var courseTable = $('#tblCourse tbody');
                    courseTable.empty();
                    $(result.data).each(function (index, course) {
                        courseTable.append(
                            `<tr><td> 
                             </td><td>  ${course.name}  
                             </td><td>  ${course.description}  
                             </td><td>  ${course.hours} 
                             </td><td>  ${ course.center.centerName} 

                             <td><a href="/Course/Details/${course.id}" type="button" class="btn" ><i class="material-icons text-primary">Details</i></a>
                                         <a href="/Course/Edit/${course.id}" type="button" class="btn" ><i class="material-icons text-warning">Edit</i></a>
                                         <a href="/Course/SoftDelete/${course.id}" type="button" class="btn js-delete" ><i class="material-icons text-danger">Delete</i></td>
                                     </td></tr>`
                            );
                    });
                    console.log(result);
                    console.log(result.data);
                },
                error: function (err) {
                    alert(err);
                }
            });
        });