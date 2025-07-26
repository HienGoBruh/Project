<div class="s_comment_list">
    <h3 class="cm_title_br">Comments <?= count($comments) ?></h3>
    <div class="s_comment_list_inner">
        <?php foreach ($comments as $comment): ?>
            <div class="media mb-3 p-2 border rounded">
                <div class="d-flex pr-3">
                    <img src="public/img/comment/comment-1.jpg" alt="" style="width: 50px; height: 50px; border-radius: 50%;">
                </div>
                <div class="media-body">
                    <h5 class="mt-0 mb-1">
                        <?= "User #" . $comment['id_nguoidung'] ?>
                        - <?= str_repeat("<i class='fa fa-star text-warning'></i>", $comment['xephang']) ?>
                    </h5>

                    <?php if (
                        isset($_SESSION['id_nguoidung']) &&
                        $_SESSION['id_nguoidung'] == $comment['id_nguoidung'] &&
                        $editId == $comment['id_bl']
                    ): ?>
                        <form onsubmit="return updateComment(this, <?= $id_banh ?>)" class="mb-2">
                            <input type="hidden" name="id_bl" value="<?= $comment['id_bl'] ?>">

                            <div class="form-group">
                                <select name="xephang" class="form-control form-control-sm w-auto d-inline-block" required>
                                    <?php for ($i = 1; $i <= 5; $i++): ?>
                                        <option value="<?= $i ?>" <?= $i == $comment['xephang'] ? 'selected' : '' ?>><?= $i ?> ⭐</option>
                                    <?php endfor; ?>
                                </select>
                            </div>

                            <div class="form-group">
                                <textarea name="noi_dung" rows="3" class="form-control" required><?= htmlspecialchars($comment['noi_dung']) ?></textarea>
                            </div>

                            <button type="submit" class="btn btn-sm btn-primary">Cập nhật</button>
                            <button type="button" class="btn btn-sm btn-secondary cancel-edit">Hủy</button>
                        </form>
                    <?php else: ?>
                        <p><?= nl2br(htmlspecialchars($comment['noi_dung'])) ?></p>
                    <?php endif; ?>

                    <div class="date_rep mt-1">
                        <small class="text-muted"><?= date("M d, Y", strtotime($comment['ngay_dang'])) ?></small>
                        <?php if (isset($_SESSION['id_nguoidung']) && $_SESSION['id_nguoidung'] == $comment['id_nguoidung']): ?>
                            <a href="#" class="edit-comment ml-3" data-idbl="<?= $comment['id_bl'] ?>">Edit</a>
                        <?php endif; ?>
                    </div>
                </div>
            </div>
        <?php endforeach; ?>
    </div>
</div>
<?php if (isset($_SESSION['id_nguoidung']) && !$da_binh_luan): ?>
    <div class="s_comment_area">
        <h3 class="cm_title_br">Leave a Comment</h3>
        <div class="s_comment_inner">
            <form class="row contact_us_form" id="commentForm" onsubmit="event.preventDefault(); addComment(<?= $id_banh ?>)" method="post">
                <input type="hidden" name="id_banh" value="<?= $id_banh ?>">
                <div class="form-group col-md-6">
                    <input type="text" class="form-control" name="name" value="<?= htmlspecialchars($_SESSION['ten_dang_nhap']) ?>" readonly>
                </div>
                <div class="form-group col-md-6">
                    <select name="xephang" class="form-control" required>
                        <option value="">Rate this cake</option>
                        <?php for ($i = 1; $i <= 5; $i++): ?>
                            <option value="<?= $i ?>"><?= $i ?> Star<?= $i > 1 ? 's' : '' ?></option>
                        <?php endfor; ?>
                    </select>
                </div>
                <div class="form-group col-md-12">
                    <textarea class="form-control" name="noi_dung" rows="3" placeholder="Write your comment..." required></textarea>
                </div>
                <div class="form-group col-md-12">
                    <button type="submit" class="btn order_s_btn form-control">Submit now</button>
                </div>
            </form>
        </div>
    </div>
<?php endif; ?>