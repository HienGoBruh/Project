
<div class="wrapper">
    <div class="sidebar" data-color="white" data-active-color="danger">
        <div class="logo">
            <a href="https://www.creative-tim.com" class="simple-text logo-mini">
                <div class="logo-image-small">
                    <img src="public/paper-dashboard-master/assets/img/logo-small.png">
                </div>
            </a>
            <?php
            require_once 'config/baseURL.php';
            if (session_status() === PHP_SESSION_NONE) {
                session_start();
            }
            if (isset($_SESSION['ten_dang_nhap'])) {
                if (($_SESSION['vai_tro'] == 'admin') || ($_SESSION['vai_tro'] == 'nhanvien')) {
                    $ten_dang_nhap = htmlspecialchars($_SESSION['ten_dang_nhap']);
                    echo "<a href='#' class='simple-text logo-normal' onclick='confirmLogout()'>$ten_dang_nhap</a>";
                } else {
                    header('Location: index.php');
                    exit;
                }
            } else {
              require_once 'config/baseURL.php';
                header('Location: ' . BASE_URL . 'dangnhap.html');
            }
            ?>
        </div>
        <div class="sidebar-wrapper">
            <ul class="nav">
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'danhmuc') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=danhmuc">
                        <i class="nc-icon nc-bullet-list-67"></i>
                        <p>category</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'nguoidung') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=nguoidung">
                        <i class="nc-icon nc-single-02"></i>
                        <p>User Profile</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'banh') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=banh">
                        <i class="fa fa-birthday-cake"></i>
                        <p>Cakes</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'khuyenmai') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=khuyenmai">
                        <i class="nc-icon nc-tag-content"></i>
                        <p>Promotions</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'tintuc') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=tintuc">
                        <i class="nc-icon nc-bullet-list-67"></i>
                        <p>News</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'loaitintuc') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=loaitintuc">
                        <i class="nc-icon nc-bullet-list-67"></i>
                        <p>News Types</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'vanchuyen') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=vanchuyen">
                        <i class="nc-icon nc-delivery-fast"></i>
                        <p>Shipping</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'pttt') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=pttt">
                        <i class="nc-icon nc-credit-card"></i>
                        <p>Payment Methods</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'binhluanbanh') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=binhluanbanh">
                        <i class="nc-icon nc-chat-33"></i>
                        <p>Cake Comments</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'binhluantintuc') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=binhluantintuc">
                        <i class="nc-icon nc-chat-33"></i>
                        <p>News Comments</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'ctdonhang') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=ctdonhang">
                        <i class="nc-icon nc-box"></i>
                        <p>Order Details</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'donhang') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=donhang">
                        <i class="nc-icon nc-delivery-fast"></i>
                        <p>Orders</p>
                    </a>
                </li>
                <li class="<?= (isset($_GET['page']) && $_GET['page'] == 'hoadon') ? 'active' : '' ?>">
                    <a href="?controller=Admin&action=index&page=hoadon">
                        <i class="nc-icon nc-money-coins"></i>
                        <p>Invoices</p>
                    </a>
                </li>
            </ul>
        </div>
    </div>
    <div class="main-panel">
        <nav class="navbar navbar-expand-lg navbar-absolute fixed-top navbar-transparent">
            <div class="container-fluid">
                <div class="navbar-wrapper">
                    <div class="navbar-toggle">
                        <button type="button" class="navbar-toggler">
                            <span class="navbar-toggler-bar bar1"></span>
                            <span class="navbar-toggler-bar bar2"></span>
                            <span class="navbar-toggler-bar bar3"></span>
                        </button>
                    </div>
                    <?php
                    $page = $_GET['page'] ?? 'danhmuc';
                    $titles = [
                        'danhmuc' => ['navbar' => 'Quản lý danh mục', 'card' => 'Danh sách danh mục'],
                        'banh' => ['navbar' => 'Quản lý bánh', 'card' => 'Danh sách bánh'],
                        'nguoidung' => ['navbar' => 'Quản lý người dùng', 'card' => 'Danh sách người dùng'],
                        'khuyenmai' => ['navbar' => 'Quản lý khuyến mãi', 'card' => 'Danh sách khuyến mãi'],
                        'tintuc' => ['navbar' => 'Quản lý tin tức', 'card' => 'Danh sách tin tức'],
                        'loaitintuc' => ['navbar' => 'Quản lý loại tin tức', 'card' => 'Danh sách loại tin tức'],
                        'vanchuyen' => ['navbar' => 'Quản lý vận chuyển', 'card' => 'Danh sách vận chuyển'],
                        'pttt' => ['navbar' => 'Quản lý PTTT', 'card' => 'Danh sách phương thức TT'],
                        'binhluanbanh' => ['navbar' => 'Bình luận bánh', 'card' => 'Danh sách bình luận bánh'],
                        'binhluantintuc' => ['navbar' => 'Bình luận tin tức', 'card' => 'Danh sách bình luận tin tức'],
                        'ctdonhang' => ['navbar' => 'Chi tiết đơn hàng', 'card' => 'Chi tiết đơn hàng'],
                        'donhang' => ['navbar' => 'Đơn hàng', 'card' => 'Danh sách đơn hàng'],
                        'hoadon' => ['navbar' => 'Hóa đơn', 'card' => 'Danh sách hóa đơn'],
                    ];
                    $navbarTitle = $titles[$page]['navbar'] ?? 'Trang quản lý';
                    $cardTitle = $titles[$page]['card'] ?? 'Danh sách';
                    ?>
                    <a class="navbar-brand" href="javascript:;"><?= $navbarTitle ?></a>
                </div>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navigation" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-bar navbar-kebab"></span>
                    <span class="navbar-toggler-bar navbar-kebab"></span>
                    <span class="navbar-toggler-bar navbar-kebab"></span>
                </button>
                <div class="collapse navbar-collapse justify-content-end" id="navigation">
                    <form onsubmit="return false;">
                        <div class="input-group no-border">
                            <input type="text" id="search-input" class="form-control" placeholder="Tìm kiếm..." autocomplete="off">
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <i class="nc-icon nc-zoom-split"></i>
                                </div>
                            </div>
                        </div>
                    </form>
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link btn-magnify" href="javascript:;">
                                <i class="nc-icon nc-layout-11"></i>
                                <p><span class="d-lg-none d-md-block">Stats</span></p>
                            </a>
                        </li>
                        <li class="nav-item btn-rotate dropdown">
                            <a class="nav-link dropdown-toggle" href="http://example.com" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="nc-icon nc-bell-55"></i>
                                <p><span class="d-lg-none d-md-block">Some Actions</span></p>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink">
                                <a class="dropdown-item" href="#">Action</a>
                                <a class="dropdown-item" href="#">Another action</a>
                                <a class="dropdown-item" href="#">Something else here</a>
                            </div>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link btn-rotate" href="javascript:;">
                                <i class="nc-icon nc-settings-gear-65"></i>
                                <p><span class="d-lg-none d-md-block">Account</span></p>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="card demo-icons">
                        <div class="card-header">
                            <h5 class="card-title" style="color: #f96332;"><?= $cardTitle ?></h5>
                        </div>
                        <div class="card-body all-icons">
                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="text-primary" id="table-head"></thead>
                                    <tbody id="table-body"></tbody>
                                </table>
                                <?php
                                $disableAdd = in_array($page, ['ctdonhang', 'donhang', 'hoadon']);
                                ?>
                                <button type="button" class="btn btn-success mt-2" <?= $disableAdd ? 'hidden' : '' ?>>Thêm</button>
                                <button type="button" id="btn-load-more" class="btn btn-primary mt-2">Xem thêm</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer class="footer footer-black footer-white">
            <div class="container-fluid">
                <div class="row">
                    <nav class="footer-nav">
                        <ul>
                            <li><a href="https://www.creative-tim.com" target="_blank">Creative Tim</a></li>
                            <li><a href="https://www.creative-tim.com/blog" target="_blank">Blog</a></li>
                            <li><a href="https://www.creative-tim.com/license" target="_blank">Licenses</a></li>
                        </ul>
                    </nav>
                    <div class="credits ml-auto">
                        <span class="copyright">
                            © <script>document.write(new Date().getFullYear())</script>, made with <i class="fa fa-heart heart"></i> by Creative Tim
                        </span>
                    </div>
                </div>
            </div>
        </footer>
    </div>
</div>
    <!-- Sidebar và Navbar giữ nguyên như trước -->
    <div class="modal fade" id="editModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Thông tin</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="form-edit" enctype="multipart/form-data">
                        <input type="hidden" name="id" id="modal-id">
                        <div id="form-fields"></div>
                        <div class="text-end">
                            <button type="submit" class="btn btn-primary">Lưu</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <script>
    let offset = 0;
    let limit = 5;
    let page = '<?php echo $_GET['page'] ?? 'danhmuc'; ?>';
    let keyword = '';
    let fields = {};
    let id_field = '';
    let table = '';
    let uploadPath = {};
    let jsonLoaded = false;

    function loadMore(reset = false) {
        if (reset) {
            offset = 0;
            $('#table-head').empty();
            $('#table-body').empty();
            $('#btn-load-more').show();
        }
        $.get(`index.php?controller=Admin&action=loadData&page=${page}&offset=${offset}&limit=${limit}&keyword=${encodeURIComponent(keyword)}`, function (res) {
            if (res.error) {
                alert('Lỗi tải dữ liệu: ' + res.error);
                return;
            }
            if (res.thead && offset === 0) {
                $('#table-head').html('<tr>' + res.thead + '</tr>');
            }
            if (res.tbody) {
                $('#table-body').append(res.tbody);
                offset += limit;
            } else {
                $('#btn-load-more').hide();
            }
        }, 'json').fail(function(xhr, status, error) {
            console.error('Load data error:', status, error);
            alert('Không thể tải dữ liệu. Vui lòng kiểm tra console.');
        });
    }

    $(document).ready(function () {
        loadMore();
        $('#btn-load-more').on('click', () => loadMore());
        $('#search-input').on('input', function () {
            keyword = this.value;
            loadMore(true);
        });

        $.getJSON(`view/Admin/field/${page}.json`, function(res) {
            fields = res.fields;
            id_field = res.id_field;
            table = res.table;
            uploadPath = res.upload_path || {};
            if (res.fields && res.fields.id_khuyenmai && res.fields.id_khuyenmai.table) {
                $.get('index.php?controller=Admin&action=getOptions&table=' + res.fields.id_khuyenmai.table + '&value=' + res.fields.id_khuyenmai.value + '&label=' + res.fields.id_khuyenmai.label_field, function(options) {
                    res.fields.id_khuyenmai.options = options;
                    fields = res.fields;
                    jsonLoaded = true;
                    bindEventHandlers();
                }, 'json').fail(function(xhr, status, error) {
                    console.error('Lỗi tải options:', status, error);
                    alert('Không thể tải options cho select. Vui lòng kiểm tra console.');
                });
            } else {
                jsonLoaded = true;
                bindEventHandlers();
            }
        }).fail(function(xhr, status, error) {
            console.error('Lỗi tải JSON:', status, error);
            alert('Không thể tải cấu hình form. Vui lòng kiểm tra console.');
        });
    });

    function bindEventHandlers() {
        $(document).on('click', '.btn-success', function () {
            if (!jsonLoaded) {
                alert('Dữ liệu JSON chưa sẵn sàng!');
                return;
            }
            $('#form-edit')[0].reset();
            $('#modal-id').val('');
            $.get(`index.php?controller=Admin&action=generateCode&page=${page}`, function(res) {
                if (res.error) {
                    alert('Lỗi tạo mã tự động: ' + res.error);
                    return;
                }
                let html = '';
                for (let key in fields) {
                    const field = fields[key];
                    const label = field.label;
                    const type = field.type;
                    const readonly = field.readonly ? 'readonly' : '';
                    const required = field.required ? 'required' : '';
                    let value = field.readonly && res.code && key.includes('ma_') ? res.code : '';
                    if (type === 'textarea') {
                        html += `<div class="mb-3">
                            <label>${label}</label>
                            <textarea name="${key}" class="form-control" ${required} ${readonly}>${value}</textarea>
                        </div>`;
                    } else if (type === 'select' && field.options) {
                        html += `<div class="mb-3">
                            <label>${label}</label>
                            <select name="${key}" class="form-control">`;
                        for (let opt in field.options) {
                            html += `<option value="${opt}">${field.options[opt]}</option>`;
                        }
                        html += `</select></div>`;
                    } else if (type === 'image') {
                        html += `<div class="mb-3">
    <label>${label}</label>
    <input type="file" name="${key}" class="form-control preview-image" data-preview="#preview-${key}">
    <img id="preview-${key}" src="${field.path || ''}${value || ''}" width="60" class="mt-1" style="display: ${value ? 'inline-block' : 'none'};">
</div>`;

                    } else {
                        html += `<div class="mb-3">
                            <label>${label}</label>
                            <input type="${type}" name="${key}" value="${value}" class="form-control" ${readonly} ${required}>
                        </div>`;
                    }
                }
                $('#form-fields').html(html);
                // Gắn sự kiện preview ảnh
$('#form-fields input.preview-image').on('change', function () {
    const input = this;
    const previewId = $(this).data('preview');
    if (input.files && input.files[0]) {
        const reader = new FileReader();
        reader.onload = function (e) {
            $(previewId).attr('src', e.target.result).show();
        };
        reader.readAsDataURL(input.files[0]);
    }
});

                $('#editModal').modal('show');
            }, 'json').fail(function(xhr, status, error) {
                console.error('Lỗi tạo mã tự động:', status, error);
                alert('Lỗi khi tạo mã tự động. Vui lòng kiểm tra console.');
            });
        });

        $(document).on('click', '.btn-edit', function () {
            if (!jsonLoaded) {
                alert('Dữ liệu JSON chưa sẵn sàng!');
                return;
            }
            const id = $(this).data('id');
            if (!id) {
                alert('ID không hợp lệ!');
                return;
            }
            $.get(`view/Admin/api/get_row.php?page=${page}&id=${id}`, function(res) {
                console.log('Dữ liệu trả về:', res);
                if (res.error) {
                    alert('Lỗi: ' + res.error);
                    return;
                }
                if (!res || Object.keys(res).length === 0) {
                    alert('Không tìm thấy dữ liệu bản ghi!');
                    return;
                }
                $('#modal-id').val(res[id_field]);
                let html = '';
                for (let key in fields) {
                    const field = fields[key];
                    const label = field.label;
                    const type = field.type;
                    const value = res[key] || '';
                    const readonly = field.readonly ? 'readonly' : '';
                    const required = field.required ? 'required' : '';
                    if (type === 'textarea') {
                        html += `<div class="mb-3">
                            <label>${label}</label>
                            <textarea name="${key}" class="form-control" ${readonly} ${required}>${value}</textarea>
                        </div>`;
     
                    } else if (type === 'select' && field.options) {
                        html += `<div class="mb-3">
                            <label>${label}</label>
                            <select name="${key}" class="form-control">`;
                        for (let opt in field.options) {
                            const selected = opt == value ? 'selected' : '';
                            html += `<option value="${opt}" ${selected}>${field.options[opt]}</option>`;
                        }
                        html += `</select></div>`;
                    } else if (type === 'image') {
    const previewId = `preview-${key}`;
    html += `<div class="mb-3">
        <label>${label}</label>
        <input type="file" name="${key}" class="form-control preview-image" data-preview="#${previewId}">
        <img id="${previewId}" src="${field.path}${value}" width="80" class="mt-2 border rounded" style="display: ${value ? 'block' : 'none'};">
    </div>`;
}
 else {
                        html += `<div class="mb-3">
                            <label>${label}</label>
                            <input type="${type}" name="${key}" value="${value}" class="form-control" ${readonly} ${required}>
                        </div>`;
                    }
                }
                $('#form-fields').html(html);
                // Gắn sự kiện preview ảnh
// Preview ảnh ngay khi chọn file
$('#form-fields input.preview-image').on('change', function () {
    const input = this;
    const previewSelector = $(this).data('preview');
    if (input.files && input.files[0]) {
        const reader = new FileReader();
        reader.onload = function (e) {
            $(previewSelector).attr('src', e.target.result).show();
        };
        reader.readAsDataURL(input.files[0]);
    }
});



                $('#editModal').modal('show');
            }, 'json').fail(function(xhr, status, error) {
                console.error('Lỗi AJAX sửa:', status, error);
                alert('Lỗi khi tải dữ liệu bản ghi. Vui lòng kiểm tra console.');
            });
        });

        $('#form-edit').on('submit', function (e) {
            e.preventDefault();
            let formData = new FormData(this);
            formData.append('table', page); // Gửi page thay vì table
            formData.append('id_field', id_field);
            for (let k in uploadPath) formData.append(`upload_path[${k}]`, uploadPath[k]);
            $.ajax({
                url: 'index.php?controller=Admin&action=insertOrUpdate',
                method: 'POST',
                data: formData,
                contentType: false,
                processData: false,
                dataType: 'json',
                success: function (res) {
                    console.log('Lưu phản hồi:', res);
                    if (res.status === 'success') {
                        $('#editModal').modal('hide');
                        alert('Lưu thành công!');
                        loadMore(true);
                    } else {
                        alert('Lưu thất bại: ' + (res.error || 'Lỗi không xác định'));
                    }
                },
                error: function(xhr, status, error) {
                    console.error('Lỗi AJAX lưu:', status, error);
                    alert('Lỗi khi lưu dữ liệu. Vui lòng kiểm tra console.');
                }
            });
        });

        $(document).on('click', '.btn-delete', function () {
            const id = $(this).data('id');
            if (!id) {
                alert('ID không hợp lệ!');
                return;
            }
            const confirmDelete = confirm('Bạn có chắc chắn muốn xóa?');
            if (!confirmDelete) return;
            $.post('index.php?controller=Admin&action=delete', {
                table: page,
                id_field: id_field,
                id: id
            }, function (res) {
                console.log('Xóa phản hồi:', res);
                if (res.status === 'deleted') {
                    alert('Xóa thành công!');
                    loadMore(true);
                } else {
                    alert('Xóa thất bại: ' + (res.error || 'Lỗi không xác định'));
                }
            }, 'json').fail(function(xhr, status, error) {
                console.error('Lỗi AJAX xóa:', status, error);
                alert('Lỗi khi gửi yêu cầu xóa. Vui lòng kiểm tra console.');
            });
        });
    }
    </script>